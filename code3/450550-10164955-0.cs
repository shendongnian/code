    Question q = new Question();
    QuestionLocation qL = new QuestLocation(){ CreateDate = DateTime.Now, Latitude = 10 , Longitude = 10 };
    q.StartDate = DateTime.Now;
    q.Objective = "foo";
    q.Location = qL;
    
    //And add newly created Quest into Database :
    DataContext.QuestLocations.Add(qL);
    DataContext.SaveChanges();
    
    DataContext.Quests.Add(q);
    DataContext.SaveChanges();
