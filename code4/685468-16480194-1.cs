      public bool SavePaymentInformation(Member member) {
   ------------------------------------------------
            using (context = new DataContext())
            {
                    MemberDetail modifiedDetail = new MemberDetail();
                    /*Clone the passed object which has changes inside it */
                    modifiedDetail = LinqHelper.Clone(member);
                    mdb.MemberDetails.Attach(modifiedDetail, true);
                    mdb.SubmitChanges();
             
            }
