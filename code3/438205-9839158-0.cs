           Button[] btns = new Button[50];
           for(int i=0;i<50;i++)
           {
                {
                //code to calculate x and y position
                    btns[i]=new Button(this);
                    //btn.SetBackgroundColor(Android.Resource.Color.);
                    btns[i].SetTextSize(Android.Util.ComplexUnitType.Sp,8);
                    btns[i].Text="Scrip "+i+"\n"+"CMP "+i+"\n"+"%Chg "+i;
                    lp = new RelativeLayout.LayoutParams(new ViewGroup.MarginLayoutParams((width+30)/5, (height-10)/10));
                    btns[i].LayoutParameters=lp;
                    lp.SetMargins(leftMargin,topMargin, 0, 0);
                    main.AddView(btn);
                }
                    
                btns[i].Click += (sender, e) => 
                {
                    String str= ( (sender as Button) != null) ? (sender as Button).Content.ToString() : "";
                    Toast.MakeText(this, "Selected="+str,ToastLength.Short).Show();
                    Console.WriteLine("Selected="+str);
                }
            }
