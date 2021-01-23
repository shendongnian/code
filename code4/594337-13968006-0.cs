    public class AppointmentStatus 
    {
         public int Id {get;set;}
         public string I18NKey {get;set;}
         public string Translation {get;set;}
    }
    public static IEnumerable<AppointmentStatus> TranslateValue(IEnumerable<AppointmentStatus> list)
        {
            foreach (var tmp in list)
            {
                tmp.Translation = I18nHelper.Message(tmp.I18NKey);
            }
            return list;
        }
    Html.DropDownListFor(x=>x.Id, new SelectList(HelperClass.TranslateValue(MyListOfStatus), "Id","Translation")
