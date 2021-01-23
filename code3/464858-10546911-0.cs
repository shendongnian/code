    const string xmlString =
                    "<module><moduleCode>ECWM618</moduleCode><moduleTitle>Semantic and Social Web</moduleTitle><credits>15</credits>" +
                    "<semester>2</semester><assessmentDetails><assessment><assessmentName>Coursework1</assessmentName><assessmentType>Coursework</assessmentType>" +
                    "<assessmentWeighting>25</assessmentWeighting></assessment><assessment><assessmentName>Coursework2</assessmentName><assessmentType>Coursework</assessmentType>" +
                    "<assessmentWeighting>25</assessmentWeighting></assessment><assessment><assessmentName>Exam</assessmentName><assessmentType>Exam</assessmentType><assessmentWeighting>50</assessmentWeighting></assessment></assessmentDetails></module>";
                var xml = XElement.Parse(xmlString);
                var qry =
                    xml.Descendants()
                        .Where(e => e.Name == "moduleCode" && e.Value == "ECWM618")
                        .Ancestors()
                        .Descendants()
                        .Where(e => e.Name == "assessmentDetails")
                        .Elements("assessment").Count();
