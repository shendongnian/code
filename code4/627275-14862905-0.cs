    public static BuyerList getBuyerList() {
      var result = new BuyerList();
      result.AddRange(one.Get());
      return result;
    }
