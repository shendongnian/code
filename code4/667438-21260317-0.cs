        public string GetAgeText(DateTime birthDate)
        {
            const double ApproxDaysPerMonth = 30.4375;
            const double ApproxDaysPerYear = 365.25;
            int iDays = (DateTime.Now - birthDate).Days;
            int iYear = (int)(iDays / ApproxDaysPerYear);
            iDays -= (int)(iYear * ApproxDaysPerYear);
            int iMonths = (int)(iDays / ApproxDaysPerMonth);
            iDays -= (int)(iMonths * ApproxDaysPerMonth);
            return string.Format("{0} år, {1} måneder, {2} dage", iYear, iMonths, iDays);
        }
