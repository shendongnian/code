    using System.Collections.Generic;
    using System.Web.Mvc;
    using RazorListTest.Models;
    namespace RazorListTest.Controllers
    {
        public class HomeController : Controller
        {
            public ActionResult Index()
            {
                AnswerScheme a = new AnswerScheme();
                a.Id = "1cd14b08-ce3b-4671-8cf8-1bcf69f12b2d";
                List<AnswerDisplayItem> adi = new List<AnswerDisplayItem>();
                AnswerDisplayItem a1 = new AnswerDisplayItem();
                a1.IsMissing = false;
                a1.Text = "Ja";
                a1.Value = "0";
                a1.Id = "1234";
                AnswerDisplayItem a2 = new AnswerDisplayItem();
                a2.IsMissing = false;
                a2.Text = "Nein";
                a2.Value = "1";
                a2.Id = "5678";
                adi.Add(a1);
                adi.Add(a2);
                a.Answers = adi;
                return View(a);
            }
            [HttpPost]
            public JsonResult AddAnswer(AnswerScheme answerScheme)
            {
                return Json("the list is in the Model.");
            }
        }
    }
