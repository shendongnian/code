        public Mapping<Address, DatabaseAddress> DatabaseAddress { get; }
        public Mapping<T1, T2> GetMapping<T1, T2>()
        {
            Mapping<T1, T2> retMapping = null;
            TypeSwitch.Do(
                typeof (T1),
                TypeSwitch.Case<Address>(() =>
                    TypeSwitch.Do(
                        typeof (T2),
                        TypeSwitch.Case<DatabaseAddress>(() => retMapping = AddressToDatabaseAddressMapping)
                ));
            return returnedMapping;
        }
