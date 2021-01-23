    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using JustAdminIt.Areas.JBI.Models;
    using JustAdminIt.Areas.JBI.ViewModels;
    using JustAdminIt.Areas.JBI.DAL;
    using System.IO;
    namespace JustAdminIt.Areas.JBI.Controllers
    { 
    public class ImageController : Controller
    {
        //private ImageContext db = new ImageContext();
        //private ProductContext pb = new ProductContext();
        private JustBundleItContext db = new JustBundleItContext();
        //
        // GET: /JBI/Image/
        public ViewResult Index()
        {
            var model = from a in db.Product
                        join b in db.Image
                        on a.productID equals b.productID
                        select new ImageViewModel
                        {
                            Product = a,
                            Image = b
                        };
            return View(model.ToList());
        }
        //
        // GET: /JBI/Image/Details/5
        public ViewResult Details(int id)
        {
            Image image = db.Image.Find(id);
            return View(image);
        }
        //
        // GET: /JBI/Image/Create
        public ActionResult Create()
        {
            return View();
        } 
        //
        // POST: /JBI/Image/Create
        //this simply populates the DB values, but does not handle the file upload
        [HttpPost]
        public ActionResult Create(Image image)
        {
            if (ModelState.IsValid)
            {
                db.Image.Add(image);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }
            return View(image);
        }
        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase Filedata)
        {
            // Verify that the user selected a file
            if (Filedata != null && Filedata.ContentLength > 0)
            {
                // extract only the fielname
                var fileName = Path.GetFileName(Filedata.FileName);
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath("~/Content/images/product/"), fileName);
                Filedata.SaveAs(path);
            }
            // redirect back to the index action to show the form once again
            return RedirectToAction("Index");
        }
        
        //
        // GET: /JBI/Image/Edit/5
 
        public ActionResult Edit(int id)
        {
            Image image = db.Image.Find(id);
            return View(image);
        }
        //
        // POST: /JBI/Image/Edit/5
        [HttpPost]
        public ActionResult Edit(Image image)
        {
            if (ModelState.IsValid)
            {
                db.Entry(image).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(image);
        }
        //
        // GET: /JBI/Image/Delete/5
 
        public ActionResult Delete(int id)
        {
            Image image = db.Image.Find(id);
            return View(image);
        }
        //
        // POST: /JBI/Image/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Image image = db.Image.Find(id);
            db.Image.Remove(image);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
    }
