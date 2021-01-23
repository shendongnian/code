            private void button10_Click(object sender, EventArgs e)
            {
    
                int[,] tempMatrix = new int[3, 3];
                tempMatrix = MakeMatrix();
                tempMatrix = SetDifferentValues(tempMatrix);
                SetButtonColor(tempMatrix, 8);
    
                Task.Factory.StartNew(
                    () => 
                    {
                        if (true)
                        {
                            Thread.Sleep(1000);
                            // ReturnButtonsDefaultColor();
                        }
                        ReturnButtonsDefaultColor(); //Need to dispatch that to the UI thread
                        Thread.Sleep(2000);
    
                        tempMatrix = ResetTempMatrix(tempMatrix); //Probably that as well
                    });
            }
