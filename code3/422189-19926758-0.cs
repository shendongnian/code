        public string SendUssdRequest(string request)
        {
            string data = TextDataConverter.StringTo7Bit(request);
            var asPDUencoded = Calc.IntToHex(TextDataConverter.SeptetsToOctetsInt(data));
            try
            {
                IProtocol protocol = _comm.GetProtocol();
                string gottenString = protocol.ExecAndReceiveMultiple("AT+CUSD=1," + asPDUencoded + ",15");
                var re = new Regex("\".*?\"");
                int i = 0;
                if (!re.IsMatch(gottenString))
                {
                    do
                    {
                        protocol.Receive(out gottenString);
                        ++i;
                    } while (!(i >= 5
                                || re.IsMatch(gottenString)
                                || gottenString.Contains("\r\nOK")
                                || gottenString.Contains("\r\nERROR")
                                || gottenString.Contains("\r\nDONE"))); //additional tests "just in case"
                }
                string m = re.Match(gottenString).Value.Trim('"');
                return PduParts.Decode7BitText(Calc.HexToInt(m));
            }
            catch { }
            finally
            {
                _comm.ReleaseProtocol();
            }
            return "";
        }
