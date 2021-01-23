                foreach(SubData subdata in data1.SubDatas)
                {
                    var t3 = new Thread(() =>
                    {
                        this.SaveData(subdata.RetrieveData());
                    }); t3.Start();
                    // NOTE: Here you are blocking each iteration of T2 
                    // while T3 runs.  There is no reason to be running 
                    // another thread here- just call SaveData/RetrieveData 
                    // from T2.  Additionally, because this is executing in 
                    // a double-nested loop, you might be doing this many, 
                    // many times.  I'd suggest looking into ThreadPool or TPL.
                    if (!t3.Join(1800000))
                    {
                        t3.Abort();
                        throw new TimeoutException("The execution of method is taking too long.");
                    }
                }
