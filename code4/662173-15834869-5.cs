		var packetArray=(
			from sig in new[] { new byte[] { 0x7e, 0x7e } }
			let find=new Func<byte[], int, IEnumerable<byte>>((x, i) => x.Skip(i).Take(sig.Length))
			let isMatch=new Func<IEnumerable<byte>, bool>(sig.SequenceEqual)
			let filtered=data.Select((x, i) => 0==i||isMatch(find(data, i-1))?i:~0)
			let indices=filtered.Where(i => ~0!=i).Concat(new[] { data.Length }).ToArray()
			from index in Enumerable.Range(1, indices.Length-1)
			let skipped=indices[index-1]
			select data.Skip(skipped).Take(indices[index]-skipped).ToArray()).ToArray();
