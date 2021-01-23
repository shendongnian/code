                bool restart = false;
                do
                {
                    restart = false;
                    Console.WriteLine("Please enter the two points that you wish to know the distance between:");
                    string point = Console.ReadLine();
                    string[] pointInput = point.Split(' ');
    
    
                    int pointNumber = Convert.ToInt16(pointInput[0]);                        //Stores the actual input number's into two integers
                    int pointNumber2 = Convert.ToInt16(pointInput[1]);
    
                    try                                                                      //Try-Catch statement to make sure that the User enters relevant PointNumbers
                    {
                        double latitude = (Convert.ToDouble(items[pointNumber * 3]));            //
                        double longtitude = (Convert.ToDouble(items[(pointNumber * 3) + 1]));    //
                        double elevation = (Convert.ToDouble(items[(pointNumber * 3) + 2]));     //
    
                        double latitude2 = (Convert.ToDouble(items[pointNumber2 * 3]));          //
                        double longtitude2 = (Convert.ToDouble(items[(pointNumber2 * 3) + 1]));  //
                        double elevation2 = (Convert.ToDouble(items[(pointNumber2 * 3) + 2]));   // Uses the relationship between the pointnumber and the array to select the required items from the array.
    
    
                        //Calculate the distance between two point using the Distance class
                        Console.WriteLine("The distance in km's to two decimal places is:");
                        Distance curDistance = new Distance(latitude, longtitude, elevation, latitude2, longtitude2, elevation2);
                        Console.WriteLine(String.Format("{0:0.00}", curDistance.toDistance()) + "km");
                    }
                    catch (IndexOutOfRangeException)
                    {
    
                        Console.WriteLine("You have selected a point number outside the range of the data entered, please select two new pointnumbers");
                        restart = true;
                    }
                } while (restart);
