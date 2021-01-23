            foreach (var flight_item in l_flights)
            {
                Console.Write('\n'+"New flight item:"+'\n');
                Console.Write('\t'+flight_item.arrivalDateTime + '\n');
                Console.Write('\t'+flight_item.arrivingCity + '\n');
                foreach (var item in flight_item.crewmember)
                {
                    var employeeId = item.Element(s + "employeeId").Value;
                    var isDepositor = item.Element(s + "isDepositor").Value;
                    var isTransmitter = item.Element(s + "isTransmitter").Value;
                    Console.Write("\t  " + employeeId + "\n");
                    Console.Write("\t  " + isDepositor + "\n");
                    Console.Write("\t  " + isTransmitter + "\n");
                }
                
            }
