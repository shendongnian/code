    catch(Exception ex)
    {
        switch (ex)
        {
        case System.InvalidOperationException:
         //Do some thing
         break;
        case System.NotSupportedException:
         //Do some thing
         break;
        case System.Web.Services.Protocols.SoapException:
         //do some thing
         break;
        ...
        ...
    }
