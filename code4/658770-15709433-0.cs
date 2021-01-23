            foreach (var winProgram in allWinPrograms.Descendants("Programs").Select(p => new
            {
                progName = p.Element("ProgramName").Value
            }))
            {
                alTemp.Add(winProgram.progName);
            }
            foreach (var linProgram in allLinPrograms.Descendants("Programs").Select(p => new
            {
                progName = p.Element("ProgramName").Value
            }))
            {
                alTemp.Add(linProgram.progName);
            }
            foreach (string newProgram in alTemp.Cast<string>().Where(newProgram => !alPrograms.Contains(newProgram)))
            {
                alPrograms.Add(newProgram);
            }
