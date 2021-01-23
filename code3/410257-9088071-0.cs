                foreach (GridViewColumn c in gv.Columns)
                {
                    // Code below was found in GridViewColumnHeader.OnGripperDoubleClicked() event handler (using Reflector)
                    // i.e. it is the same code that is executed when the gripper is double clicked
                    // if (adjustAllColumns || App.StaticGabeLib.FieldDefsGrid[colNum].DispGrid)
                        if (double.IsNaN(c.Width))
                        {
                            c.Width = c.ActualWidth;
                        }
                        c.Width = double.NaN;
                }  
