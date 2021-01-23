    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AutoMapper;
    namespace GroupingMapping
    {
        public class PeriodRequest
        {
            public IEnumerable<Period> Periods { get; set; }
            public IEnumerable<DateTime> Weeks { get; set; }
        }
        
        public class RowViewModel
        {
            public string DayName { get; set; }
            public string SchoolclassCode { get; set; }
            public string Content { get; set; }
            public int DayIndex { get; set; }
            public int LessonNumber { get; set; }
        }
        public class Period
        {
            public int PeriodId { get; set; }
            public DateTime LessonDate { get; set; }
            public int LessonNumber { get; set; }
            public string SchoolclassCode { get; set; }
            public string Content { get; set; }
            public int SchoolyearId { get; set; }
            // No definition provided for Schoolyear
            //public Schoolyear Schoolyear { get; set; }
        }
        public class CellViewModel
        {
            public CellViewModel()
            {
                Rows = new List<RowViewModel>();
            }
            public CellViewModel(IEnumerable<RowViewModel> rowVMSet)
            {
                Rows = new List<RowViewModel>(rowVMSet);
            }
            public List<RowViewModel> Rows { get; set; }
        }
        public class PeriodListViewModelEx
        {
            public PeriodListViewModelEx(IEnumerable<Period> periods)
            {
                CellViewModels = new List<CellViewModel>(periods
                    .GroupBy(p => p.LessonNumber)
                    .OrderBy(grp => grp.Key)
                    .Select(grp =>
                    {
                        return new CellViewModel(
                            grp.Select(p => { return Mapper.Map<Period, RowViewModel>(p); }));
                    }));
            }
            public List<CellViewModel> CellViewModels { get; set; }
        }
        class DateTimeToDateNameResolver : ValueResolver<DateTime, string>
        {
            protected override string ResolveCore(DateTime source)
            {
                return source.ToShortDateString();
            }
        }
        class DateTimeToDayOfWeekResolver : ValueResolver<DateTime, int>
        {
            protected override int ResolveCore(DateTime source)
            {
                return (int)source.DayOfWeek;
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Mapper.CreateMap<Period, RowViewModel>()
                    .ForMember(dest => dest.DayName, opt => opt.ResolveUsing<DateTimeToDateNameResolver>().FromMember(src => src.LessonDate))
                    .ForMember(dest => dest.DayIndex, opt => opt.ResolveUsing<DateTimeToDayOfWeekResolver>().FromMember(src => src.LessonDate));
                Period[] periods = new Period[3];
                periods[0] = new Period { PeriodId = 1, LessonDate = DateTime.Today.Add(new TimeSpan(1, 0, 0, 0)), LessonNumber = 101, SchoolclassCode = "CS101", Content = "Intro to CS", SchoolyearId = 2013 };
                periods[1] = new Period { PeriodId = 2, LessonDate = DateTime.Today.Add(new TimeSpan(2, 0, 0, 0)), LessonNumber = 101, SchoolclassCode = "CS101", Content = "Intro to CS", SchoolyearId = 2013 };
                periods[2] = new Period { PeriodId = 3, LessonDate = DateTime.Today.Add(new TimeSpan(1, 0, 0, 0)), LessonNumber = 102, SchoolclassCode = "EN101", Content = "English (I)", SchoolyearId = 2013 };
                PeriodListViewModelEx pvModel = new PeriodListViewModelEx(periods);
                Console.WriteLine("CellViews: {0}", pvModel.CellViewModels.Count);
                foreach (CellViewModel cvm in pvModel.CellViewModels)
                {
                    Console.WriteLine("{0} items in CellViewModel Group", cvm.Rows.Count);
                }
                Console.WriteLine("Inspecting CellViewModel Rows");
                foreach (CellViewModel cvm in pvModel.CellViewModels)
                {
                    foreach (RowViewModel rvm in cvm.Rows)
                    {
                        Console.WriteLine("  DayName: {0}", rvm.DayName);
                        Console.WriteLine("  SchoolclassCode: {0}", rvm.SchoolclassCode);
                        Console.WriteLine("  Content: {0}", rvm.Content);
                        Console.WriteLine("  DayIndex: {0}", rvm.DayIndex);
                        Console.WriteLine("  LessonNumber: {0}", rvm.LessonNumber);
                        Console.WriteLine("  -");
                    }
                    Console.WriteLine("--");
                }
                Console.ReadKey();
            }
        }
    }
