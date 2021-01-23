    [HttpGet]
    public ActionResult Question(string email, string serializedModel)
    {
        // Deserialize your model back to a list again here.
        List<QuestionClass.Tabelfields> model = JsonConvert.DeserializeObject<List<QuestionClass.Tabelfields>>(serializedModel);
    }
