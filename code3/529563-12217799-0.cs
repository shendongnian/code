var csv =
    from line in File.ReadAllLines("C:/file.csv")
    let customerRecord = line.Split(',')
    select new Customer()
        {
            contactID = customerRecord[0],
            surveyDate = <b>DateTime.Parse(</b>customerRecord[1]<b>)</b>,
            project = customerRecord[2],
            projectCode = customerRecord[3]
        };
public class Customer
{
    public string contactID { get; set; }
    public <b>DateTime</b> surveyDate { get; set; }
    public string project { get; set; }
    public string projectCode { get; set; }
}
