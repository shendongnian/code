    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using AESSmart.ViewModels;
    
    namespace AESSmart.Controllers
    {
      public class HomeController : Controller
      {
        public ActionResult Index()
        {
          HomeIndexViewModel IndexViewModel = new HomeIndexViewModel();
    
          IndexViewModel.startingDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
          IndexViewModel.endingDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
          IndexViewModel.setUTCDatesTimes();
          IndexViewModel.setWeather();
          IndexViewModel.setOffsetsAndPowerGenerated();
          IndexViewModel.Message = "Welcome to the Amptech Energy Systems Solar PV Monitoring System";
          
          return View(IndexViewModel);
        }
    
        [HttpPost]
        public ActionResult Index(HomeIndexViewModel IndexViewModel)
        {
          if (Convert.ToString(IndexViewModel.startingDate) == "1/1/0001 12:00:00 AM" || 
              Convert.ToString(IndexViewModel.endingDate) == "1/1/0001 12:00:00 AM")  
          {
            return RedirectToAction("Index");
          }
    
          IndexViewModel.setUTCDatesTimes();
          IndexViewModel.setWeather();
          IndexViewModel.setOffsetsAndPowerGenerated();
          IndexViewModel.Message = "Welcome to the Solar PV Monitoring System";
    
          return View(IndexViewModel);
        }     
      }
    }
