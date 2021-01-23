    var questionCategory = questionnaire.QuestionCategories.FirstOrDefault(x => x.Type == (int)questionCategoryType);
    
    return questionCategory != null
    		? questionCategory.Questions.Select(x => new 
                                                     {
                                                        Id = x.Id,
                                                        Text = x.Text,
                                                     })
            : someDefaultValue;													
