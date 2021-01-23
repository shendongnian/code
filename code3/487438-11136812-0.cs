    catch (Exception ex)
                {
                    MessageBox.Show("An exception has occured. Please check the Excel sheet for more info" + ex);
                    return someDefautOrErrorValue; // <- add return statement here
                }
                finally
                {
                    GC.Collect();   
                }
                return someDefautOrErrorValue; // <- or alternately here.
            }
