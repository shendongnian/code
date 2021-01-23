    public class Currency {
        public double Amount {get;set;}
        public string Symbol {get;set;}
        public override string ToString() {
            return String.Format(Symbol + "{0}",Amount);
        }
    }
    public Currency SearchMedicinePrice(Int64 pNDC) {
        Currency retValue = null;
        objConext = new FDBEntities();
        Medicine objMedicine = objConext.Medicines.Where(med => med.PriceType == 9 && med.NDC == pNDC).OrderByDescending(item=>item.MedicineID).FirstOrDefault();
        if (objMedicine != null)
        {
            retValue.Amount = objMedicine.Price;
            retValue.Symbol = objMedicine.CurrencySymbol;
        }
        return retValue;
    }
