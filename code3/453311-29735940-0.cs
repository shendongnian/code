                          @{
                                int a = 0;
                                int b = 0;
                            }
                       <li>
                            @foreach (var item in Model.NameHere)
                            {
                               //write code here
                                a++;
                                if (a == Model.Offices.Count() / 2)
                                {
                                    break;
                                }
                            }
                        </li>
                        <li>
                            @foreach (var item in Model.NameHere)
                            {
                                if (b >= Model.Offices.Count() / 2)
                                {
                                    //write code here
                                }
                                b++;
                            }
                        </li>
