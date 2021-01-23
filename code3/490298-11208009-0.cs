    int i = myPane.AddYAxis("");
    myPane.YAxisList[i].Color = Color.Orange;
    myPane.YAxisList[i].Scale.IsVisible = false;
    myPane.YAxisList[i].MajorTic.IsAllTics = false;
    myPane.YAxisList[i].MinorTic.IsAllTics = false;
    myPane.YAxisList[i].Cross = pointOnXAxisThatIWantToMark;
