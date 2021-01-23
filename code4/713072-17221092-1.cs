    struct orders {
        signed long long replID; // i8
        signed long long replRev; // i8
        signed long long replAct; // i8
        signed long long id_ord; // i8
        signed long long id_ord1; // i8
        signed int status; // i4
        signed int isin_id; // i4
        signed int amount; // i4
        signed int amount_rest; // i4
        signed int init_amount; // i4
        signed char action; // i1
        signed char dir; // i1
        char price[11]; // d16.5
};
