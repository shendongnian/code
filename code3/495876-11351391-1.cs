            var orders = (from cert in _orderRepository.GetAll()
                          join cert2 in _orderRepository.GetAll()
                          on cert.CardNumber equals cert2.CardNumber
                          where !cert.PrintedPackSlip 
                          where !cert2.PrintedPackSlip
                          group cert by cert
                          into certGrp
                          select certGrp).ToDictionary(o => o.Key,o => o.Count())
