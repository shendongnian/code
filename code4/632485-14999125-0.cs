    bool status = false;
            bool statusChange = false;
            while (true)
            {
                if (IsOnline())
                {
                    if (status == false && statusChange == false)
                        statusChange = status = true;
                    else if (status == false && statusChange == true)
                        status = true;
                    else if (status == true && statusChange == false) ;
                    else if (status == true && statusChange == true)
                        statusChange = false;
                }
                else
                {
                    if (status == false && statusChange == false) ;
                    else if (status == false && statusChange == true)
                        status = statusChange = false;
                    else if (status == true && statusChange == false)
                    {
                        status = false;
                        statusChange = true;
                    }
                    else if (status == true && statusChange == true)
                        statusChange = false;
                }
                if (statusChange)
                {
                    UpdateStaus(status);
                }
            }
