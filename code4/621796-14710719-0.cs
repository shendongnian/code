    public static bool IsOlderThanThreeAndHasAbcProductType(Contract contract)
    {
        if (contract.account.Age > 3
            && contract.productList.Any(a => a.ProductType == "abc"))
        {
            return true;
        }
        return false;
    }
    List<Contract> sel = contractList.Where(IsOlderThanThreeAndHasAbcProductType).ToList();
