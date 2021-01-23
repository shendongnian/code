    00001F21 11:48:00.351013   7104.1           :       Exception received
    System.FormatException
    Message: Input string was not in a correct format.
    StackTrace:
       at System.Number.ParseSingle(String value, NumberStyles options, NumberFormatInfo numfmt)
       at System.Convert.ToSingle(String value)
       at IBM.WMQ.MQMarshalMessageForGet.GetValueAsObject(String dt, String propValue)
       at IBM.WMQ.MQMarshalMessageForGet.ProcessAllAvailableRFHs()
    00001F22 11:48:00.351115   7104.1           :       We are not sucessful in parsing one of theRFH2Header.Raise the RFH_FORMAT exception and breakfurther processing in loop
    00001F23 11:48:00.351825   7104.1           :       MQException CompCode: 2 Reason: 2421
