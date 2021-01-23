                        var big = new Bitmap(strImageBig);
                        var little1 = new Bitmap(saLittle[0]);
                        var little2 = new Bitmap(saLittle[1]);
                        var little3 = new Bitmap(saLittle[2]);
                        Invoke((ThreadStart)delegate()
                        {
                            picBig.Image = big;
                            picLittle1.Image = little1;
                            picLittle2.Image = little2;
                            picLittle3.Image = little3;
                        });                    
