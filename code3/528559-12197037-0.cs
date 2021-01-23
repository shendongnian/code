      StringBuilder fullName = new StringBuilder();
                List<string> lines = new List<string>();
                if (!string.IsNullOrEmpty(address.Name))
                    fullName.AppendFormat("{0} ", address.Name);
                if (!string.IsNullOrEmpty(address.Name1))
                    fullName.AppendFormat("{0} ", address.Name1);
                if (!string.IsNullOrEmpty(address.Name2))
                    fullName.Append(address.Name2);
                if (!string.IsNullOrEmpty(fullName.ToString()))
                    lines.Add(fullName.ToString());
