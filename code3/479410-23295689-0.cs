    try to use 
    MembershipCreateStatus status;
            if (consumer.UserId == Guid.Empty)
            {
                consumer.UserId = Guid.NewGuid();
            }
            if (consumer.ConsumerId == Guid.Empty)
            {
                consumer.ConsumerId = Guid.NewGuid();
            }
            try
            {
                var membershipUser = System.Web.Security.Membership.CreateUser(consumer.UserName, consumer.Password, consumer.Email, null, null, consumer.IsApproved, consumer.UserId, out status);
            }
