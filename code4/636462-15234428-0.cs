     try
            {
                var _newSettlement = new Settlement
                                            {
                                                CreateDate = settlement.CreateDate,
                                                DriverID = settlement.DriverID,
                                                CarID = settlement.CarID,
                                                DocPath = settlement.DocPath
                                            };
                Add(_newSettlement);
                _success = SaveWithSuccess() > 0;
                var _settlement = GetAll().FirstOrDefault(x => x.SettlementID == _newSettlement.SettlementID);
                if (_success)
                {
                    foreach (var _shift in settlement.Shifts)
                    {
                        var _sh = _diaryRepository.GetShiftByID(_shift.ShiftID).FirstOrDefault();
                        _sh.SettlementID = _settlement.SettlementID;
                        _diaryRepository.UpdateShift(_sh);
                    }
                    foreach (var _cost in settlement.Costs)
                    {
                        var _ch = _costRepository.GetCostByID(_cost.CostID);
                        _ch.SettlementID = _settlement.SettlementID;
                        _costRepository.UpdateCost(_ch);
                    }
                }
            }
