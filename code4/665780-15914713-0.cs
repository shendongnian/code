        String xmlString = @"<root type=""service"">
            <Msg Date=""03/23/2013 12:00:04 AM"">Request'HANDSHAKE'</Msg>
            <Msg Date=""03/23/2013 12:00:04 AM"">Response'RSHANDSHAKE'</Msg>
            <Msg Date=""03/23/2013 12:03:04 AM"">Request'HANDSHAKE'</Msg>
            <Msg Date=""03/23/2013 12:03:04 AM"">Response'RSHANDSHAKE'</Msg>
            <Msg Date=""03/23/2013 01:34:30 PM"">Request 'IQ~bbabb3ff2-...DLE~VNECTRECVBDHANDLE'</Msg>
            <Msg Date=""03/23/2013 01:34:30 PM"">Response SIQ~7a23da12...RDHANDLE=O000000000014'</Msg>
        </root>";
        String[] data = xmlString.Split(new string[] { "/Msg"},  StringSplitOptions.None);
        int errors = 0;
        Boolean secondLine = false;
        for (int i = 0; i+1 < data.Length; i ++ )
        {
            if (secondLine)
            {
                if (!data[i].Contains("Response"))
                {
                    errors += 1;
                }
                secondLine = false;
            }
            else
            {
                if (!data[i].Contains("Request"))
                {
                    errors += 1;
                }
                else
                {
                    secondLine = true;
                }
            }
        }
        if (secondLine) { errors += 1; }
        System.Windows.Forms.MessageBox.Show("Errors: " + errors.ToString());
