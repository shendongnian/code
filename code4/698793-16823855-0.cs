    HttpResponseMessage Modify(HttpResponseMessage response) {
            T content;
            if(response.TryGetContentValue<T>(out content)) {
                DoSomethingWithContent(content);
            }
            else 
            {
               IEnumerable<T> content;
               if(response.TryGetContentValue<IEnumerable<T>>(out content)) {
                DoSomethingWithContent(content);
               }
            }
            return response;
        }
