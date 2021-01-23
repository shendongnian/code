     foreach(Member memeber in memeberList)
     {
            List<Payment> memberPayments=GetMemberPayments(member.Id);
            //also you need to check that memberPayments.Count>0
            if(memberPayments[0].EndDay<DateTime.Today)
            {
               member.Status = Status.Unpaid.ToString();
            }
     }
