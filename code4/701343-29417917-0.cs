                byte[] ch = service.GetChallenge();
                String sData = BitConverter.ToString(ch).Replace("-", "");
                byte[] bResp = Encrypt("000000000000000000000000000000000000000000000000", "0000000000000000", sData);//key, and iv
                service.ExternalAuthenticate(bResp);
                if (service.IsAuthenticated(2))//2-Admin,1-User
                {
                    byte[] ch1 = service.GetChallenge();
                    String sData1 = BitConverter.ToString(ch1).Replace("-", "");
                    byte[] bResp1 = Encrypt("000000000000000000000000000000000000000000000000", "0000000000000000", sData1);
                    service.ChangeReferenceData(0, 2, bResp1, b_newpin , -1);//for Admin PIN
                    //service.ChangeReferenceData(0, 1, Encoding.ASCII.GetBytes(userpin), Encoding.ASCII.GetBytes("0001"), -1);//for User PIN
                } 
