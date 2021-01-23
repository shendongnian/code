    foreach (var rate in rateing)
                    {
                        sum += Convert.ToInt32(rate.Rate);
                    }
                    if(rateing.Count()!= 0)
                    {
                        float avg = (float)sum / (float)rateing.Count();
                        saloonusers.Rate = avg;
                    }
                    else
                    {
                        saloonusers.Rate = (float)0.0;
                    }
