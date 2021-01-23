            void Session_Start(object sender, EventArgs e)
            {
                //3. Lock the dataSet to prevent synchronization issues.  
                lock (lockObj)
                {
                    //4. Increment hits in the dataSet.
                    dataSet.Tables[0].Rows[0]["hits"] = 1 + int.Parse(dataSet.Tables[0].Rows[0]["hits"].ToString());
                    //5. Write the new value to the long-term storage, counter.xml
                    dataSet.WriteXml(Server.MapPath("~/counter.xml"));
                }
            }
        }
    }
