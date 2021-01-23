        /**
        * calculateMac
        * Calculates the MAC key from a Dictionary<string, string> and a secret key
        * @param params_dict The Dictionary<string, string> object containing all keys and their values for MAC calculation
        * @param K_hexEnc String containing the hex encoded secret key from DIBS Admin
        * @return String containig the hex encoded MAC key calculated
        **/
        public static string calculateMac(Dictionary<string, string> paramsDict, string kHexEnc)
        {
            //Create the message for MAC calculation sorted by the key
            var keys = paramsDict.Keys.ToList();
            keys.Sort();
            var msg = "";
            foreach (var key in keys)
            {
                if (key != keys[0]) msg += "&";
                msg += key + "=" + paramsDict[key];
            }
            //Decoding the secret Hex encoded key and getting the bytes for MAC calculation
            var kBytes = new byte[kHexEnc.Length / 2];
            for (var i = 0; i < kBytes.Length; i++)
            {
                kBytes[i] = byte.Parse(kHexEnc.Substring(i * 2, 2), NumberStyles.HexNumber);
            }
            //Getting bytes from message
            var msgBytes = Encoding.Default.GetBytes(msg);
            //Calculate MAC key
            var hash = new HMACSHA256(kBytes);
            var macBytes = hash.ComputeHash(msgBytes);
            var mac = BitConverter.ToString(macBytes).Replace("-", "").ToLower();
            return mac;
        }
