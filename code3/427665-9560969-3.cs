    public class DoubleMap {
        HashMap<Double, Alerter> mAscend, mDescend;
        PriorityQueue<Double> pricesAscending, pricesDescending;
        public DoubleMap()
        {
            pricesAscending = new PriorityQueue<Double>(100);
            pricesDescending = new PriorityQueue<Double>(100, new ReverseComparator());
        }
    
        public void Add(boolean rAscend, double value, int size)
        {
            Map<Double, Alerter> map = rAscend ? mAscend : mDescend;
            Alerter to = map.get(value);
            if ( to != null )
            {
                Alerter.size += size;
            }
            else 
            {
                to = new Alerter (size);           
                map.put(value, to);
                pricesAscending.offer(value);
                pricesDescending.offer(value);
            }
        }
        public void Remove(boolean rAscend, double value, int size)
        {
            Map<Double, Alerter> map = rAscend ? mAscend : mDecend;
            Alerter to = map.get(value);
            if ( to != null )
            {
                long nsize = to.size - size;
                if ( nsize <= 0 )
                    map.remove(value);
                    pricesAscending.remove(value);
                    pricesDescending.remove(value);
                else
                    to.size = nsize;
            }
        }
        public void Ondata(double rValue)
        {
            while (pricesAscending.peek() < rValue) {
                mAscend.getValue(pricesAscending.peek()).LatencySensitiveAction();
                mAscend.remove(pricesAscending.poll());
            }
            while (pricesDescending.peek() > rValue) {
                mDescend.getValue(pricesDescending.peek()).LatencySensitiveAction();
                mDescend.remove(pricesDescending.poll());
            }
        }
    }
