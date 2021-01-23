    List<BlueBallRect> listOfBlueBallRect = new List<BlueBallRect>();
    listOfBlueBallRect = SomeMethodThatGetsListOfBlueBallRect;
    foreach(BlueBallRect in listOfBlueBallRect)
    {
        if(doesBallIntersect = DoesIntersect(topRect, bottomRect, BlueBallRect))
        {
            // Do something here, because they intersect
        }
        else
        {
            // Do something else here, because they do not intersect
        }
    }
