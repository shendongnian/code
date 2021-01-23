            // imagine several dozens of lines that look like this
            // where the result is the return value of a function call
            fields.Add(new ProbeField(){ 
                Command = "A",
                Field = "Average",
                Value = be.GetAverage()
            });
            // now you need something that can't be expressed as function call
            // so you wrap it in a lambda and immediately call it.
            fields.Add(new ProbeField(){ 
                Command = "C",
                Field = "Cal Coeff",
                Value = ((Func<string>)(() => {
                    CalCoef coef;
                    Param param;
                    be.GetCalibrationCoefficients(out coef, out param);
                    return coef.lowDet1.ToString();
                }))()
            });
