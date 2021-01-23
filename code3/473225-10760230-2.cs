    class ConsumerOfIUser
    {
       public int Consume(IUser user)
       {
          return user.CalculateAge() + 10;
       }
    }
