     public  void GetBehavior(string behaviorName, ref TutorialPopupBehavior b) {
                foreach(TutorialPopupBehavior beh in _tutorialItems) {
                    if(beh._popupName == behaviorName) {
                        b = beh;
                         Return;
                    }
                }
                print ("Could not find behavior of name " + behaviorName);
                b = null;
            }
