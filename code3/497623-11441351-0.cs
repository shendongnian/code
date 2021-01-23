    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;
    using System.Globalization;
    using System.Web.Mvc;
    
    namespace ManyToMany.Models
    {
        public class Hour
        {
            
            //public string Name { get; set; }
            //public string Url { get; set; }
            public int HourID { get; set; }
           // public virtual Week Week { get; set; }
            public int? WeekID { get; set; }
            //[Key]
            public int? ActivityID { get; set; }
            public virtual Activity Activity { get; set; }
            //public int ActivtityID { get; set; }
    
    
    
    
    
    
            //[DisplayFormat(ApplyFormatInEditMode=true, DataFormatString="{0:c}")]
            //public decimal? Amount { get; set; }
            
    
            [ReadOnly(true)]
            //[DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
            public decimal HourTotal { get { return GetTotalHours(); }   }
    
            
    
            public int WeekNumber { get; set; }
            public int yearNumber { get; set; }
    
            //Properties days:
           
            public DayOfWeek DayWeek { get; set; }
            
            //public DateTime DateDay { get; set; }
              
            
           [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
            public DateTime? Monday { get; set; }
            public int Days { get; set; }
    
           
            [DataType(DataType.Date)]//
            [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
            public DateTime? Tuesday { get; set; }
            
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
            public DateTime? Wendsday { get; set; }
            
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
            public DateTime? Thursday { get; set; }
            
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
            public DateTime? Fryday { get; set; }
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
            public DateTime? Saterday { get; set; }
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
            public DateTime? Sunday { get; set; }
            //End properties days
            
    
            //Properties hours:
           // [DisplayFormat(DataFormatString = "{0:#.##0.0#}", ApplyFormatInEditMode = true)]
            [Required]
            //[DisplayFormat(DataFormatString= "{0:#,##0.000#}")] 
            public Decimal MondayHours { get; set; }
            //[DisplayFormat(DataFormatString = "{0:#.#}", ApplyFormatInEditMode = true)]
            [Required]
            public Decimal TuesdayHours { get; set; }
            //[DisplayFormat(DataFormatString = "{0:#.#}", ApplyFormatInEditMode = true)]
            [Required]
            public Decimal WendsdayHours { get; set; }
            //[DisplayFormat(DataFormatString = "{0:#.#}", ApplyFormatInEditMode = true)]
            [Required]
            public Decimal ThursdayHours { get; set; }
            //[DisplayFormat(DataFormatString = "{0:#.#}", ApplyFormatInEditMode = true)]
            [Required]
            public Decimal FrydayHours { get; set; }
            //[DisplayFormat(DataFormatString = "{0:#.#}", ApplyFormatInEditMode = true)]
            [Required]
            public Decimal SaterdayHours { get; set; }
            //[DisplayFormat(DataFormatString = "{0:#.#}", ApplyFormatInEditMode = true)]
            [Required]
            public Decimal SundayHOurs { get; set; }
    
            public string TextMonday { get; set; }
            public string TextTuesday { get; set; }
            public string TextWendsday { get; set; }
            public string TextThursday { get; set; }
            public string TextFryday { get; set; }
            public string TextSaterday { get; set; }
            public string TextSunday { get; set; }
    
    
    
    
    
            public decimal GetTotalHours()
            {
                return MondayHours + 
                       TuesdayHours + 
                       WendsdayHours + 
                       ThursdayHours + 
                       FrydayHours + 
                       SaterdayHours +
                       SundayHOurs;
            }
              
    
            
    
            //public IEnumerable<SelectListItem> Hour { get; set; }
            
    
            
            public Hour()
            {
    
                //Activity = new List<Activity>();
    
                this.yearNumber = DateTime.Now.Year;
    
                Days = DateTime.Now.DayOfWeek - DayOfWeek.Monday;
                Monday = DateTime.Now.AddDays(-Days);
                Tuesday =  DateTime.Now.AddDays(0);// .Monday.AddDays(1).ToShortDateString();//.ToShortDateString());
                Wendsday = DateTime.Now.AddDays(1);  //DateTime.Parse(Monday.AddDays(2).ToShortDateString());
                Thursday = DateTime.Now.AddDays(2);    //DateTime.Parse(Monday.AddDays(3).ToShortDateString());
                Fryday = DateTime.Now.AddDays(3);          //DateTime.Parse(Monday.AddDays(4).ToShortDateString());
                Saterday = DateTime.Now.AddDays(4);              //DateTime.Parse(Monday.AddDays(5).ToShortDateString());
                Sunday =   DateTime.Now.AddDays(5);             //DateTime.Parse(Monday.AddDays(6).ToShortDateString());
    
                this.WeekNumber = System.Threading.Thread.CurrentThread.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Now, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
            }
        }
    }
