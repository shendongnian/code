    string target = Path.Combine(destinationDir, hcp + "{" + hcpCd + "~" + hcpID + "}" + hcpName + "{2013_03_14}.pdf");
    while(File.Exists(target))
            {
                i++;
                target = Path.Combine(destinationDir, hcp + "{" + hcpCd + "~" + hcpID + "}" + hcpName + "{2013_03_14}" + i + ".pdf");
                
            }
    File.Copy(fileSource, target);
    break;
