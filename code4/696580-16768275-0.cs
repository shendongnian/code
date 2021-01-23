    public string ConvertToDescription(double amount, string originalMeasurement, params string[] toMeasurements)
    {
        StringBuilder sb = new StringBuilder();
        double valueToConvert = amount;
        string priorMeasurement = originalMeasurement;
        double displayAmount;
        for (int i = 0; i < toMeasurements.Count; i++)
        {
             if (i > 0)
                 sb.Append(" ");
              double convertedAmount = VolumeMeasurements(valueToConvert, priorMeasurement, toMeasurement[i]);
              // Check if last item so we don't trim wanted decimals.
              if (i < toMeasurements.Count - 1)
                  displayAmount = Math.Floor(convertedAmount)
              else
                  displayAmount = convertedAmount;
              valueToConvert = convertedAmount - displayAmount;
              priorMeasurement = toMeasurements[i];
              
              // You will need to add logic here to display fractions if needed.
              sb.AppendFormat("{0} {1}", displayAmount, toMeasurements[i]);
            
              if (fixedAmount == 0)
                  break;
        }
        return sb.ToString();
    }
