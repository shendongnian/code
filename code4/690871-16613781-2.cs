    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using MvcDemo.Models;
    namespace MvcDemo.Controllers
    {
    public class ColorsController : Controller
    {
        //
        // GET: /Colors/
        ColorContext cc = new ColorContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost, ActionName("update")]
        public ActionResult Update(int id)
        {
            Color color = cc.Colors.Find(id);
            cc.Colors.Remove(color);
            cc.SaveChanges();
            return RedirectToAction("Index");
        }
    }
    }    
