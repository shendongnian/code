    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    
    namespace SoQna.Controllers
    {
      public class HomeController : Controller
      {
        IList<SoQna.Models.Question> _qnaRepo = new List<SoQna.Models.Question>
        {
          new SoQna.Models.Question { QuestionId = 1, 
            QuestionText = 
              "Why is there a proliferation of different kind of ORMs?" 
          },
          new SoQna.Models.Question { 
              QuestionId = 2, QuestionText = "How are you?" 
          },
          new SoQna.Models.Question { 
              QuestionId = 3, QuestionText = "Why the sky is blue?" 
          },          
          new SoQna.Models.Question { 
              QuestionId = 4, QuestionText = "Why is MVC the bees knees?" 
          },          
        };
    
    
        public ActionResult Index()
        {
          var qna = new SoQna.ViewModels.QnaViewModel { 
              Answers = new List<SoQna.ViewModels.AnswerToQuestion>() 
          };
          
          foreach (var question in _qnaRepo)
          {
            if (question.QuestionId == 1) continue; // subjective :-)
    
            qna.Answers.Add(
              new SoQna.ViewModels.AnswerToQuestion { 
                  ToQuestionId = question.QuestionId, 
                  QuestionText = question.QuestionText, 
                  AnswerText = "Put your answer here" 
              }
            );         
          }
              
          return View(qna);
        }
    
        [HttpPost]
        public ViewResult SubmitAnswers(SoQna.ViewModels.QnaViewModel a)
        {
          foreach (var answer in a.Answers)
          {
            answer.QuestionText = _qnaRepo.Single(x => 
               x.QuestionId == answer.ToQuestionId).QuestionText;
          }
          return View(a);
        }
    
      }//HomeController
    }//namespace
