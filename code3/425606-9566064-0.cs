            catch (Exception e)
            {
                //Do some logging. NOTE taking this "catch" out "fixes" the problem, but I can't do this in prod.
                System.Diagnostics.Debug.WriteLine(e.Message);
                caughtException = new MemoryStream();
                BinaryFormatter exceptionFormatter = new BinaryFormatter(); // Exception raised on this line
                exceptionFormatter.Serialize(caughtException, e);
                caughtException.Seek(0, SeekOrigin.Begin);
            }
            finally
            {
                ReportStackSpaceUsage();
                System.Diagnostics.Debug.WriteLine("<-- RecurseXTimes()");
                if (caughtException != null)
                {
                    BinaryFormatter exceptionFormatter = new BinaryFormatter();
                    Exception e = (Exception)exceptionFormatter.Deserialize(caughtException);
                    throw e;
                }
            }
