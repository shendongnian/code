    List<BlueBallRect> listOfBlueBallRect = new List<BlueBallRect>();
    listOfBlueBallRect = SomeMethodThatGetsListOfBlueBallRect;
    foreach(BlueBallRect ball in listOfBlueBallRect)
    {
        if(DoesIntersect(topRect, bottomRect, ball))
        {
            // Do something here, because they intersect
        }
        else
        {
            // Do something else here, because they do not intersect
        }
    }
