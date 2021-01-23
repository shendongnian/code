     private static UserControl CreatePopup(PopupModel model){
        switch (model.ScreenType)
        {
            case Screens.Type1:
                popup = new PopupType1();
                break;
            case Screens.Type2:
                popup = new PopupType2();
                break;
            case Screens.Type3:
                popup = new PopupType3();
                break;
            case Screens.Type4:
                popup = new PopupType4();
                break;
        }
     }
