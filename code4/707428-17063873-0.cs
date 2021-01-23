    for (int i = 0; i < fooBarObjects.Count; i++)
    {
        var bar1 = fooBarObjects[i] as Bar1;
        if (bar1 != null)
            bar1.anotherMethodBar1();
        else {
            var bar2 = fooBarObjects[i] as Bar2;
            if (bar2 != null)
                bar2.anotherMethodBar2();
        }
    }
