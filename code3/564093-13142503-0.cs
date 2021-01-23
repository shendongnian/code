        property IObservable<bool> CanDo;
        public IObservable<bool> RegisterCanDo( IObservable<bool> toRegister ){
                if ( CanDo == null ){
                        CanDo = toRegister;
                }else{
                        Cando = CanDo.CombineLatest(toRegister, (a,b) => a && b);
                }
        }
