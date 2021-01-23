    [HttpPost]
    public ActionResult QuestionsAndAnswers(Answers[] answers)
    {
                    foreach (var item in answers)
                    {
                        // do whatever you want here
                    }
                    return View();
    }
