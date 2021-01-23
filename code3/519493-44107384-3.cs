    namespace OOPS
    {
        using Interfaces;
        using System;
        using System.Collections.Generic;
    
        public class BusinessLogic
        {
            public void Print<T>(IBannerContent<T> bannerContent) where T : IBanner
            {
                foreach (var item in bannerContent.Banners)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var banner1 = new Simple.BannerContent
                {
                    Banners = new List<Simple.Banner>
                    {
                        new Simple.Banner { Name = "Banner 1" },
                        new Simple.Banner { Name = "Banner 2" }
                    }
                };
    
                var banner2 = new Complex.BannerContent
                {
                    Banners = new List<Complex.Banner>
                    {
                        new Complex.Banner { Name = "Banner 3", Description = "Test Banner" },
                        new Complex.Banner { Name = "Banner 4", Description = "Design Banner" }
                    }
                };
    
                var business = new BusinessLogic();
                business.Print(banner1);
                business.Print(banner2);
                Console.ReadLine();
            }
        }
    }
