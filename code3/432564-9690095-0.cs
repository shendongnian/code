    public void DoWhatever(){
         PCPAppointmentDateTime = ParseDate(templates.Descendants("element").SingleOrDefault(el => el.Attribute("name").Value == "PCPAppointmentDateTime").Attribute("value").Value);
    }
    
    private DateTime ParseDate(string dateString){
        DateTime date;
        if (DateTime.TryParse(dateString, out date))
             return date;
        return DateTime.MinValue;
    }
