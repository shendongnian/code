    partial void AgeAtDiagnosis_Compute(ref int result)
            {
                if(DateofDiagnosis.HasValue && DateofBirth.HasValue)
                {
                    // Set result to the desired field value
                    result = DateofDiagnosis.Value.Year - DateofBirth.Value.Year;
                    if (DateofBirth > DateofDiagnosis.Value.AddYears(-result))
                    {
                      result--;
                    }
                }
            }
