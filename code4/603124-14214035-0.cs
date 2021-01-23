    container.CoinMessageSet.Where(
                    c => c.MessageState != MessageStateType.Closed &&
                         (c.DonorOperator.OperatorCode.Equals("opcode") ||
                          c.RecipientOperator.OperatorCode.Equals("opcode"))
                    ).OrderByDescending(c => c.TimeStamp)
                     .GroupBy(c => c.Reference).OrderByDescending(c = > c.Key).Skip(x).Take(100);
