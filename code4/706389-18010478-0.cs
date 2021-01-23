    if (e.Direction.ToString() == "Horizontal") //Left or right
                {
                    if (e.HorizontalVelocity > 0) //Right
                    {
                        Pivot.CurrentItem=Pivot.CurrentItem+1; //don't remember the code for changing the page...
                    }
                    else //Left
                    {
                        Pivot.CurrentItem=Pivot.CurrentItem-1;
                    }
                }
